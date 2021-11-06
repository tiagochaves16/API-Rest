using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        internal ReadGerenteDto AdicionaGerente(CreateGerenteDto dto)
        {

            Gerentes gerente = _mapper.Map<Gerentes>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);

        }

        internal ReadGerenteDto RecuperaGerentesPorId(int id)
        {
            Gerentes gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return gerenteDto;

            }
            return null; 
        }
    }
}
