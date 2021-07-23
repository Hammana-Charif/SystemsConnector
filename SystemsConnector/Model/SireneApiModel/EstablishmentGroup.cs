namespace SystemsConnector.Model.SireneApiModel
{
    class EstablishmentGroup : BaseEntity
    {
        /// <summary>
        /// Mappage à "etablissement" lorsque l'api Sirene renvoi un etablissement unique
        /// </summary>
        public Establishment Etablissement { get; set; }

        /// <summary>
        /// Mappage à "etablissements" lorsque l'api Sirene renvoi une liste d'établissements
        /// </summary>
        public Establishment Etablissements { get; set; }
    }
}
