using System;
using System.Collections.Generic;

namespace TaskImpiegati.Models;

public partial class CittaDiResidenza
{
    public int CittaDiResidenzaId { get; set; }

    public string NomeCitta { get; set; } = null!;

    public int ProvinciaRif { get; set; }

    public virtual ProvinciaDiResidenza ProvinciaRifNavigation { get; set; } = null!;
}
