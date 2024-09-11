using detaInterview.Models;

namespace detaInterview.Serivce
{
    public interface IDetailService
    {
        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns></returns>
        IEnumerable<Detail> GetList();

        /// <summary>
        /// 取得單一資料
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        Detail Get(string pk);


        /// <summary>
        /// 新增or修改
        /// </summary>
        /// <param name="model"></param>
        void Set(Detail model);


        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="pk"></param>
        void Delete(string pk);
    }
}
