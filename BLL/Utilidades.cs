using System;
using System.Collections.Generic;

public class Utiidades
{
    public static int ToInt(string valor)
    {
        int retorno = 0;

        int.TryParse(valor, out retorno);

        return retorno;
    }
}
