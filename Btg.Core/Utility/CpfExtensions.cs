﻿namespace Btg.Core.Utility;

public static class CpfExtensions
{
    public static string RemoveNaoNumericos(string text)
    {
        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
        string ret = reg.Replace(text, string.Empty);
        return ret;
    }

    public static string ToCPF(this string valor)
    {
        return Convert.ToUInt64(valor.Trim()).ToString(@"000\.000\.000\-00");
    }

    public static bool IsValidCpf(this string cpf)
    {
        //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
        cpf = RemoveNaoNumericos(cpf);

        if (cpf.Length > 11)
            return false;

        while (cpf.Length != 11)
            cpf = '0' + cpf;

        bool igual = true;
        for (int i = 1; i < 11 && igual; i++)
            if (cpf[i] != cpf[0])
                igual = false;

        if (igual || cpf == "12345678909")
            return false;

        int[] numeros = new int[11];

        for (int i = 0; i < 11; i++)
            numeros[i] = int.Parse(cpf[i].ToString());

        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (10 - i) * numeros[i];

        int resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[9] != 0)
                return false;
        }
        else if (numeros[9] != 11 - resultado)
            return false;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (11 - i) * numeros[i];

        resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[10] != 0)
                return false;
        }
        else
            if (numeros[10] != 11 - resultado)
            return false;

        return true;
    }

}