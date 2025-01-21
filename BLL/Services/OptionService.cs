using BLL.DTOs;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OptionService
    {
        readonly OptionRepo optionRepo = new OptionRepo();
        readonly MapperService mapperService = new MapperService();

        public CreateOptionDto AddOption(CreateOptionDto createOption)
        {
            var newOption = optionRepo.Add(mapperService.MapCreateOption(createOption));

            return mapperService.MapOptionToCreateOptionDto(newOption);
        }
    }
}
