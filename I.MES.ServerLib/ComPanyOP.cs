using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I.MES.Library.EF;

namespace I.MES.Library
{
    [Shareable]
    public class ComPanyOP : BaseOP
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ComPanyOP(ClientInformation clientInfo)
            : base(clientInfo)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DBSource"></param>
        public ComPanyOP(ClientInformation clientInfo, DataEntities DBSource)
            : base(clientInfo, DBSource)
        {
        }
        [Shareable]
        public List<SYS_Company> GetList()
        {
            var item = DB.SYS_Company.ToList();
            return item;
        }

        [Shareable]
        public List<SYS_Company> GetList(string txtSearch, int PageNumber, int PageSize, out int total)
        {
            var item = DB.SYS_Company;
            total = item.Count();
            var data = item.OrderBy(p => p.ID).Skip((PageNumber - 1) * PageSize).Take(PageSize);
            return data.ToList();
        }

        [Shareable]
        public int Update(int id, string CompanyName, string CompanyFullName)
        {
            var item = DB.SYS_Company.FirstOrDefault(p => p.ID == id);

            item.CompanyName = CompanyName;
            item.CompanyFullName = CompanyFullName;

            return DB.SaveChanges();

        }

        [Shareable]
        public List<SYS_Company> GetCompanyList()
        {
            var item = DB.SYS_Company.ToList();
            return item;

        }
        [Shareable]
        public SYS_Company GetCompany(string CompanyCode)
        {
            SYS_Company info = DB.SYS_Company.Where(p => p.CompanyCode == CompanyCode).FirstOrDefault();
            return info;
        }

        [Shareable]
        public void Update(SYS_Company company)
        {

            if (company.ID == 0)
            {
                company.CreateMachine = this.MachineName;
                company.CreateTime = DateTime.Now;
                company.CreateUserAccount = this.UserAccount;
                company.LatestModifyMachine = this.MachineName;
                company.LatestModifyTime = DateTime.Now;
                company.LatestModifyUserAccount = this.UserAccount;
                company.CompanyHUCode = string.Empty;
                Insert<SYS_Company>(company);
            }
            else
            {
                company.LatestModifyMachine = this.MachineName;
                company.LatestModifyTime = DateTime.Now;
                company.LatestModifyUserAccount = this.UserAccount;
                company.CompanyHUCode = string.Empty;
                Update<SYS_Company>(company);
            }
        }
    }
}
