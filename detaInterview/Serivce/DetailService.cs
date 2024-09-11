using detaInterview.Models;
using detaInterview.Repository.UnitOfWork;
using detaInterview.ViewModel;

namespace detaInterview.Serivce
{
    public class DetailService :IDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Detail> GetList()
        {

            //取得所有資料的部分 那我這邊就先用假資料來演示
            List<Detail> queryable = new List<Detail>()
            {
                new Detail()
                {
                    name = "001",
                    birthday = DateTime.Now.ToString(),
                    enable = "true",
                    gender = "1",
                    id = "1",
                    pk = "1",
                    pwd = "EXAM",
                    remark = "測試資料1"
                },
                new Detail()
                {
                    name = "002",
                    birthday = DateTime.Now.ToString(),
                    enable = "true",
                    gender = "1",
                    id = "1",
                    pk = "2",
                    pwd = "EXAM",
                    remark = "測試資料2"
                }
            };
            ///這個方法會去跟資料庫要資料，但這邊沒有連線資料庫所以就回傳假資料
            //var getData = _unitOfWork.Repository<Detail>().GetAll();
            return queryable;
        }


        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public Detail Get(string pk)
        {

            //取得所有資料的部分 那我這邊就先用假資料來演示
            var getData = new Detail()
            {
                name = "",
                birthday = DateTime.Now.ToString(),
                enable = "true",
                gender = "1",
                id = "1",
                pk = "1",
                pwd = "EXAM",
                remark = "測試資料"
            };
            //主要是針對取得全部資料後 給予Where條件後取得單筆資料
            //var getData = _unitOfWork.Repository<Detail>().GetAll().Where(o=>o.pk == pk).SingleOrDefault();
            return getData;
        }

        /// <summary>
        /// 新增or修改
        /// </summary>
        /// <param name="model"></param>
        public void Set(Detail model)
        {
            ///這邊一樣會跟資料庫做結合所以如果直接打過去會有問題
            try
            {
                //if (model.pk == null || model.pk == "")
                //{
                //    _unitOfWork.Repository<Detail>().Add(model);
                //}
                //else
                //{
                //    _unitOfWork.Repository<Detail>().Update(model);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            
        }


        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="pk"></param>
        public void Delete(string pk)
        {
            ///這邊一樣會跟資料庫做結合所以如果直接打過去會有問題
            try
            {
                //var deleteData = _unitOfWork.Repository<Detail>().GetAll().Where(o=>o.pk == pk).SingleOrDefault();
                //if (deleteData != null)
                //{
                //    _unitOfWork.Repository<Detail>().Remove(deleteData);
                //}
                
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
