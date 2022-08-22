using Internship.Models;
using System.Collections.Generic;


namespace Internship.Services
{
    public static class CompanyAPIService
    {
        static List<CompanyAPI> companies { get; }
        static CompanyAPIService()
        {
            companies = new List<CompanyAPI> { };
            {
                new CompanyAPI
                {
                    CompanyCode = 1,
                    CompanyName = "L&T Construction",
                };
                new CompanyAPI
                {
                    CompanyCode = 2,
                    CompanyName = "L&T Infotech",
                };
        }
        }

        public static List<CompanyAPI> GetAll()
        {
            return companies;
        }

        public static CompanyAPI Get(int id)
        {
            CompanyAPI? p = companies.Find(p => p.CompanyCode == id);
            return p ?? throw new Exception("Companies not Found");
        }

        public static void Add(CompanyAPI company)
        {
            companies.Add(company);
        }
}
}