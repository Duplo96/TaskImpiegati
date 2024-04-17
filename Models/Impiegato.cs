using System;
using System.Collections.Generic;

namespace TaskImpiegati.Models;

public partial class Impiegato
{
    public int ImpiegatoId { get; set; }

    public string Matricola { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateOnly DataDiNascita { get; set; }

    public string Ruolo { get; set; } = null!;

    public string Reparto { get; set; } = null!;

    public string IndirizzoDiResidenza { get; set; } = null!;

    public string CittaDiResidenza { get; set; } = null!;

    public string ProvinciaDiResidenza { get; set; } = null!;
}
