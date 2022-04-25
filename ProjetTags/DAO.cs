namespace ProjetTags
{
    public abstract class DAO<T>
    {
        /// <summary>Permet de retourver un objet par son identifiant</summary>
        /// <param name="idt">identifiant de l'objet</param>
        /// <returns>l'objet</returns>
        public abstract T FindByIdt(int idt);

        /// <summary>Permet d'insérer une instance de l'objet dans la bdd</summary>
        /// <param name="obj">Objet à insérer</param>
        /// <returns>l'objet</returns>
        public abstract T Insert(T obj);

        /// <summary>Permet de mettre à jour un objet dans la bdd</summary>
        /// <param name="tag">Objet à mettre à jour</param>
        /// <returns>l'objet</returns>
        public abstract T Update(T tag);

        /// <summary>Permet de supprimer un objet de la bdd</summary>
        /// <param name="obj">Objet à supprimer</param>
        public abstract void Delete(T obj);
    }
}