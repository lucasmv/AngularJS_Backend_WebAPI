using AutoMapper;
using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteWebAPI.Models;

namespace TesteWebAPI.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Operadora, OperadoraDTO>().ReverseMap();
                cfg.CreateMap<Contato, ContatoDTO>().ReverseMap();

                //cfg.CreateMap<UsuarioDTO, Usuario>();
            });
        }
    }
}