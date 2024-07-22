namespace DataLayer.Mapper.Interfaces
{
    public interface IMapper<T, M>
    {
        M FromDTO(T dto);

        T ToDTO(M model);
    }
}