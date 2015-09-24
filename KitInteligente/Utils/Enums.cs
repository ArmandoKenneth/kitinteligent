using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Utils
{
    public class Enums
    {
    }

    public enum TiposTransacoes
    {
        ENTRADA = 1,
        SAIDA = 2
    }

    public enum Categorias
    {
        BEBIDA = 1,
        HIGIENE = 2,
        FRUTAS = 3,
        VERDURAS = 4,
        CARNE = 5,
        ALIMENTO = 6
    }

    public enum NivelServico
    {
        NV50  = 1,
        NV60 = 2,
        NV70 = 3,
        NV80 = 4,
        NV85 = 5,
        NV90 = 6,
        NV95 = 7,
        NV96 = 8,
        NV97 = 9,
        NV98 = 10,
        NV99 = 11,
        NV99_90 = 12,
        NV99_99 = 13
    }
}