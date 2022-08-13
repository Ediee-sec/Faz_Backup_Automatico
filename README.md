## Programa que faz backup automático.

> *Está necessidade surgiu em ambiente de trabalho em que meu gestor me solicitou que eu fizesse backups diariamente de todos arquivos de consfigurações do nosso sistema, contando todos os slaves do sistema incluido o broker eram 26 pastas em que eu deveria ir e fazer o backup dos arquivos .ini.*

> *Como um bom amante da automação claramente eu não iria  fazer este processo que poderia levar horas de forma manual, então decidi fazer um programa que realiza-se este processo para mim, a linguagem que escolhi para desenvolver o programa foi o C# a qual estou estudando atualmente.*

> **A intenção é fazer com que este programa execute toda vez que eu iniciar o windows**

> *Abaixo irei explicar como o programa funciona, os nomes das pastas e caminhos eu alterei, para preservar o ambiente da empresa.*

----

* ### Mapa do Código

1. **Função Principal (Main)**
> Aqui realizo todas as funcionalidades do programa.
~~~C#
class Program
{
	// Declarando a constante que é o caminho onde os arquivos serão salvos.
    const string PathDest = $@"C:\Users\T-Gamer\Documents\Backups\";
	
	// Iniciando a função principal
    static void Main(string[] args)
    {
		// Tratamento de erro
        try
        {
			// Array que ira conter o nome das pastas onde os arquivos .ini estarão
            string[] PathsSrc = new string[4]
            {
                "pasta1","pasta2","pasta3","pasta4"
            };

			// contador para verificar se o while continua ou para
            int cont = 0;

			// while, enquanto o meu contator for menor que o tamanho do array eu continuo o loop
            while (cont <= PathsSrc.Length)
            {
				// foreach, para iterar sobre todas as posições o array, e joga o valor de cada posição na variavel str
                foreach (string str in PathsSrc)
                {
					// variavel Src, é onde iremos pegar os arquivos .ini
                    string Src = $@"C:\{str}\appserver.txt";
					//variavel Dest, é onde iremos salvas os arquivos .ini
                    string Dest = $@"{PathDest}\{str}";
					
					// valida se o diretorio existe no caminho de destino, se não existir ele cria com base nos nomes do array
                    if (ValidPath(str) == false)
                    {
                        Directory.CreateDirectory(Dest);
                    }
					// valida se o arquivo já existe destro da pasta de destino, se existir ele não faz nada, se não existir ele cola o arquivo
                    if (ValidFile(NameFile(Dest)) == false)
                    {
                        File.Copy(sourceFileName: Src,
                                destFileName: NameFile(Dest),
                                overwrite: true);
                    }
                }
				// ao final do loop adciona +1 a variavel cont
                cont++;
            }
			// se tem erro na operação exite uma menssagem de erro genérica
        }catch (Exception)
        {
            Console.WriteLine("Erro");
            throw;
        }
    }
~~~
----

2. **Função que vai renomear o arquivo quando for colcar na pasta de destino**
> Está função tem por finalidade renomear o arquivo antes de colar na pasta de destino.

~~~C#
// iniciando a função, com um parâmetro obrigatório do tipo string
static string NameFile(string a)
{
	// pega a data e hora atual do sistema
    DateTime dt = DateTime.Now;
	// formata a data para o formato anomesdia e retira as horas
    string DateFormat = dt.ToString("yyyyMMdd");
	// Nomeia o arquivo
    string cNameFile = $"{a}/appserver_backup_{DateFormat}.ini";
	// retorno da função
    return cNameFile;
}
~~~
-----------

3. **Função que vai verificar se o arquivo já existe na pasta**
> Está função irá validar se o arquivo já existe, subsequentemente chamo a função em condicionais da função Main.

~~~C#
// Retorna verdadeiro ou falso
static bool ValidFile(string a)
    {
        Boolean file = File.Exists(a);
        return file;
    }
~~~
------

4. **Função que vai verificar se a pasta em que o arquivo será colado já existe**
> Está função irá validar se o pasta já existe, subsequentemente chamo a função em condicionais da função Main.
~~~C#
// Retorna verdadeiro ou falso
static bool ValidPath(string a)
    {
        Boolean path = Directory.Exists($@"{PathDest}\{a}");
        return path;
    }
~~~

