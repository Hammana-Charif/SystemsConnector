namespace SystemsConnector.Model.SireneApiModel
{
    class Establishment : BaseEntity
    {
        public string Siren { get; set; }
        public string Nic { get; set; }
        public string DateCreationEtablissement { get; set; }

        /// <summary>
        /// Mappage au sous tableau "uniteLegale" dans le tableau renvoyé par l'api Sirene
        /// </summary>
        public UniteLegal UniteLegale { get; set; }

        /// <summary>
        /// Mappage au sous tableau "adresseEtablissement" dans le tableau renvoyé par l'api Sirene
        /// </summary>
        public Address AdresseEtablissement { get; set; }
    }
}
