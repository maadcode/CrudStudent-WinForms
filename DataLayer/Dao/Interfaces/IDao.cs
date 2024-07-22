using CrossCutingLayer.Dto.Standard;
using System.Collections.Generic;

namespace DataLayer.Dao.Interfaces
{
    public interface IDao<T>
    {
        List<T> GetAll();
        ResponseDto Add(T model);
        ResponseDto Delete(int modelId);
        ResponseDto Update(T model);
    }
}