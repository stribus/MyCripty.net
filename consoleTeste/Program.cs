using Crypto;

Console.WriteLine("Hello, World!");

MyCrypto myCripty = new MyCrypto(7, "3a9873f36b140fde0441d929a43e0bfae41f2d5c");

string texto = "texto para criptografar";
string criptografado = myCripty.Encrypt(texto);
string descriptografado = myCripty.Decrypt(criptografado);

Console.WriteLine($"Texto: {texto}");
Console.WriteLine($"Criptografado: {criptografado}");
Console.WriteLine($"Descriptografado: {descriptografado}");



