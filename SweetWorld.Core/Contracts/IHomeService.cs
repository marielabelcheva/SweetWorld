using SweetWorld.Core.Models.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Contracts
{
    public interface IHomeService
    {
        public void ContactUs(ContactUsViewModel viewModel);
    }
}
