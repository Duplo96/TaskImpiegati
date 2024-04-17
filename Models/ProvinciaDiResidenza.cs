using System;
using System.Collections.Generic;

namespace TaskImpiegati.Models;

public partial class ProvinciaDiResidenza
{
    public int ProvinciaDiResidenzaId { get; set; }

    public string NomeProvincia { get; set; } = null!;

    public string Sigla { get; set; } = null!;

    public virtual ICollection<CittaDiResidenza> CittaDiResidenzas { get; set; } = new List<CittaDiResidenza>();
}
