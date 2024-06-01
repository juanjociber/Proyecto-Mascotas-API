namespace BACKEND_CRUD.Models.Repository
{
    public interface IMascotaRepository 
    {
        //Listado de Mascotas
        Task<List<Mascota>>GetListMascotas();

        //Mostrar Mascota por Id
        Task<Mascota> GetMascota(int id);

        //Eliminar Mascota
        Task DeleteMascota(Mascota mascota);

        Task<Mascota> AddMascota(Mascota mascota);

        Task UpdateMascota(Mascota mascota);
    }
}
