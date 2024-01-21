using Construtor_Classe;

try
{
    Email email = new("Nicolas Fischer", "nicolasfischer1@gmail.com", "senhav@l1da", "nicolasfischer2@gmail.com", false, SetorUsuario.TI);

    Console.WriteLine("Informações válidas!");
    Console.ReadLine();
}
catch (NomeUsuarioInvalidoException ex)
{
    Console.WriteLine(ex.Message);
}
catch (EmailInvalidoException ex)
{
    Console.WriteLine(ex.Message);
}
catch (EmailRecuperacaoInvalidoException ex)
{
    Console.WriteLine(ex.Message);
}
catch (SenhaInvalidaException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex) // Captura quaisquer erros não previstos pelas exceções anteriores
{
    Console.WriteLine("Erro não esperado: " + ex.Message);
    throw;
}
