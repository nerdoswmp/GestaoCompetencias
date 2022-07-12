// See https://aka.ms/new-console-template for more information
using GestaoCompetencias.Models;

using var context = new DB_Gestao_CompetenciasContext();

context.Database.EnsureCreated();
