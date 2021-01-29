using System;

namespace Revisao
{
    class Program
    {   
        public static string obterOpcaoUsuario()
        {
            string opcaoSelecionada;

            Console.WriteLine("\nInforme a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("0 - Sair\n");

            
            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;

            string opcaoUsuario = obterOpcaoUsuario();


            while (opcaoUsuario != "0")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        
                        Console.WriteLine("Informe a nota do aluno:");
           
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("O valor da nota deve ser decimal.\n");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    
                    case "2":
                        foreach (var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        break;
                    
                    case "3":
                        decimal notaTotal = 0;
                        var qtdeAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                qtdeAlunos++;
                            }
                        }   

                        Conceito conceitoGeral;

                        var mediaGeral = notaTotal / qtdeAlunos;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                    

                        Console.WriteLine($"Média geral: {mediaGeral} - Conceito: {conceitoGeral}");
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterOpcaoUsuario();
            }
        }
    }
}
