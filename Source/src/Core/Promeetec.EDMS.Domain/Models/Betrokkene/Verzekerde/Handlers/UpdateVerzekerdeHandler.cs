﻿using Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Handlers
{
    public class UpdateVerzekerdeHandler : ICommandHandlerAsync<UpdateVerzekerde>
    {
        private readonly IVerzekerdeRepository _repository;

        public UpdateVerzekerdeHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(UpdateVerzekerde command)
        {
            var verzekerde = await _repository.GetByIdAsync(command.AggregateRootId);
            if (verzekerde == null)
                throw new ApplicationException($"Client niet gevonden. Id: {command.AggregateRootId}");

            // Adresgegevens zijn gewijzigd
            if (verzekerde.Adres.Straat != command.Adres.Straat
                || verzekerde.Adres.Huisnummer != command.Adres.Huisnummer
                || verzekerde.Adres.Huisnummertoevoeging != command.Adres.Huisnummertoevoeging
                || verzekerde.Adres.Postcode != command.Adres.Postcode
                || verzekerde.Adres.Woonplaats != command.Adres.Woonplaats
                || verzekerde.Adres.LandId != command.Adres.LandId)
            {
                var currentAdres = verzekerde.Adres;
                currentAdres.WoonachtigTot = DateTime.Now;
                verzekerde.Adressen.Add(currentAdres);

                verzekerde.Adres = command.Adres;
            }


            // Zorgverzekering is gewijzigd
            if (verzekerde.Zorgverzekering.VerzekeraarId != command.Zorgverzekering.VerzekeraarId)
            {
                var currentZorgverzekering = verzekerde.Zorgverzekering;
                currentZorgverzekering.VerzekerdTot = DateTime.Now;
                verzekerde.Zorgverzekeringen.Add(currentZorgverzekering);

                verzekerde.Zorgverzekering = command.Zorgverzekering;
            }


            if (command.Zorgprofiel != null)
            {
                // Hier is iets fout gegaan
                if (command.Zorgprofiel.ProfielStartdatum == DateTime.MinValue)
                    throw new Exception("De profiel startdatum is ongeldig! Neem contact op met Promeetec.");


                if (verzekerde.Zorgprofiel == null)
                {
                    // Verzekerde heeft nog geen profiel dus maak aan
                    verzekerde.Zorgprofiel = command.Zorgprofiel;
                }
                else
                {
                    // Het profiel is gewijzigd...
                    if (command.Zorgprofiel.ProfielCode != verzekerde.Zorgprofiel.ProfielCode)
                    {
                        switch (command.Zorgprofiel.ProfielCode)
                        {
                            case ProfielCode.Geen:


                                if (command.Zorgprofiel.ProfielEinddatum > verzekerde.Zorgprofiel.ProfielStartdatum)
                                {
                                    // De gekozen einddatum ligt na de startdatum van het huidige profiel. Dit is correct
                                }
                                else if (command.Zorgprofiel.ProfielEinddatum == verzekerde.Zorgprofiel.ProfielStartdatum)
                                {
                                    // De gekozen einddatum iS GELIJK aan de startdatum van het huidige profiel
                                    // De gekozen einddatum wordt met 1 dag verhoogd
                                    command.Zorgprofiel.ProfielEinddatum = command.Zorgprofiel.ProfielEinddatum.Value.AddDays(+1);

                                }
                                else
                                {
                                    // De gekozen einddatum ligt VOOR de startdatum van het huidige profiel

                                    // De einddatum voor het nieuwe profiel moet bepaald worden..
                                    while (command.Zorgprofiel.ProfielEinddatum <= verzekerde.Zorgprofiel.ProfielStartdatum)
                                    {
                                        command.Zorgprofiel.ProfielEinddatum = command.Zorgprofiel.ProfielEinddatum.Value.AddDays(+1);
                                    }
                                }

                                // De einddatum van het vorig profiel wordt de einddatum van het nieuwe profiel
                                verzekerde.Zorgprofiel.ProfielEinddatum = command.Zorgprofiel.ProfielEinddatum;

                                // De startdatum van profiel 'Geen' wordt de einddatum van het oude profiel.
                                command.Zorgprofiel.ProfielStartdatum = verzekerde.Zorgprofiel.ProfielEinddatum.Value;

                                verzekerde.Zorgprofielen.Add(verzekerde.Zorgprofiel);

                                break;
                            case ProfielCode.ProfielCode0:
                            case ProfielCode.ProfielCode1:
                            case ProfielCode.ProfielCode2:
                            case ProfielCode.ProfielCode3:
                            case ProfielCode.ProfielCode4:
                            case ProfielCode.ProfielCode5:
                            case ProfielCode.ProfielCode6:
                            case ProfielCode.ProfielCode7:


                                if (command.Zorgprofiel.ProfielStartdatum > verzekerde.Zorgprofiel.ProfielStartdatum)
                                {
                                    // De gekozen startdatum ligt na de startdatum van het huidige profiel. Dit is correct
                                }
                                else if (command.Zorgprofiel.ProfielStartdatum == verzekerde.Zorgprofiel.ProfielStartdatum)
                                {
                                    // De gekozen startdatum iS GELIJK aan de startdatum van het huidige profiel dus we verhogen de startdatum met 1 dag
                                    command.Zorgprofiel.ProfielStartdatum = command.Zorgprofiel.ProfielStartdatum.AddDays(+1);

                                }
                                else
                                {
                                    // De gekozen startdatum ligt VOOR de startdatum van het huidige profiel.
                                    // De startdatum voor het nieuwe profiel moet bepaald worden..
                                    while (command.Zorgprofiel.ProfielStartdatum <= verzekerde.Zorgprofiel.ProfielStartdatum)
                                    {
                                        command.Zorgprofiel.ProfielStartdatum = command.Zorgprofiel.ProfielStartdatum.AddDays(+1);
                                    }
                                }

                                if (command.Zorgprofiel.ProfielStartdatum.AddDays(-1) >= verzekerde.Zorgprofiel.ProfielStartdatum)
                                {
                                    // Dit is correct
                                    verzekerde.Zorgprofiel.ProfielEinddatum = command.Zorgprofiel.ProfielStartdatum.AddDays(-1);
                                }
                                else
                                {
                                    // Dit mag niet voorkomen
                                    throw new Exception("Profiel datums zijn ongeldig. Neem contact op met Promeetec.");
                                }

                                verzekerde.Zorgprofielen.Add(verzekerde.Zorgprofiel);

                                break;
                        }
                    }
                }
            }

            verzekerde.Update(command);
            await _repository.UpdateAsync(verzekerde);

            return new CommandResponse
            {
                Events = verzekerde.Events
            };
        }
    }
}