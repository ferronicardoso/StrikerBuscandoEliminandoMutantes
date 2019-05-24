using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TesteMutacao
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var assemblyPath = args[0];
                var fileInfo = new FileInfo(assemblyPath);

                if (fileInfo.Exists)
                {
                    var directoryFile = Path.GetDirectoryName(assemblyPath);
                    var oldFileName = Path.GetFileNameWithoutExtension(assemblyPath);
                    var extensionFile = Path.GetExtension(assemblyPath);
                    var newAssemblyPath = Path.Combine(directoryFile, string.Format("{0}{1}{2}", oldFileName, ".old", extensionFile));
                    File.Copy(assemblyPath, newAssemblyPath, true);

                    using (var assemblyDefinition = AssemblyDefinition.ReadAssembly(assemblyPath, new ReaderParameters { ReadingMode = ReadingMode.Immediate, ReadWrite = true, InMemory = true }))
                    {
                        var moduleDefinition = assemblyDefinition.MainModule;

                        ReplaceInstructions(moduleDefinition);

                        moduleDefinition.Write(assemblyPath);
                    }
                }
            }
        }

        private static void ReplaceInstructions(ModuleDefinition moduleDefinition)
        {
            var typeDefinitionList = moduleDefinition.Types
                                                    .Where(t => t.Name != "<Module>")
                                                    .Select(t => new
                                                    {
                                                        t.Name,
                                                        MethodBody = t.Methods.Where(m => m.Name != ".ctor")
                                                                            .Select(m => new { m.Name, m.Body })
                                                                            .ToList()
                                                    })
                                                    .ToList();

            typeDefinitionList.ForEach(typeDefinition =>
            {
                Console.WriteLine(typeDefinition.Name);

                typeDefinition.MethodBody.ForEach(methodDefinition =>
                {
                    var oldInstructionList = methodDefinition.Body.Instructions.Where(i => i.OpCode == OpCodes.Call).ToList();

                    oldInstructionList.ForEach(oldInstruction =>
                    {
                        if (oldInstruction != null)
                        {
                            var oldOperationName = ((MemberReference)oldInstruction.Operand).Name;
                            var newOperationName = string.Empty;

                            switch (oldOperationName)
                            {
                                case "op_Addition":
                                    newOperationName = "op_Subtraction";
                                    break;
                                case "op_Subtraction":
                                    newOperationName = "op_Addition";
                                    break;
                                case "op_Multiply":
                                    newOperationName = "op_Division";
                                    break;
                                case "op_Division":
                                    newOperationName = "op_Multiply";
                                    break;
                                case "op_Equality":
                                    newOperationName = "op_Inequality";
                                    break;
                                case "op_Inequality":
                                    newOperationName = "op_Equality";
                                    break;
                            }

                            var methodInfo = typeof(decimal).GetMethod(newOperationName, new Type[] { typeof(decimal), typeof(decimal) });
                            var methodReference = moduleDefinition.ImportReference(methodInfo);

                            var il = methodDefinition.Body.GetILProcessor();
                            var newInstruction = il.Create(OpCodes.Call, methodReference);
                            il.Replace(oldInstruction, newInstruction);

                            Console.WriteLine("{0}: {1} ==> {2}", methodDefinition.Name, oldOperationName, newOperationName);
                        }
                    });
                });
            });
        }
    }
}
