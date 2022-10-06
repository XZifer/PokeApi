using Microsoft.AspNetCore.Mvc;
using Pkmn.Datos;
using Pkmn.Modelos.Clases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        public Pokemones pokemones = new();
        // GET: api/<PokemonController>
        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            return pokemones.ListaPokemones;
        }

        // GET api/<PokemonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PokemonController>
        [HttpPost]
        public IEnumerable<Pokemon> Post(Pokemon p)
        {
            Pokemon? existe = pokemones.ListaPokemones.FirstOrDefault(x => x.Nombre == p.Nombre);
            if (existe == null)
            {
                pokemones.ListaPokemones.Add(p);
            }
            
            return pokemones.ListaPokemones;
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{nombre}")]
        public IEnumerable<Pokemon> Put(string nombre, Pokemon pkmnupdate)
        {
            Pokemon? pkmnexistente = pokemones.ListaPokemones.FirstOrDefault(x => x.Nombre == nombre);
            Pokemon? pkmnduplicado = pokemones.ListaPokemones.FirstOrDefault(x => x.Nombre == pkmnupdate.Nombre);
            if (pkmnexistente != null
                && pkmnupdate == null   )
            {
                pokemones.ListaPokemones.Remove(pkmnexistente);
                pokemones.ListaPokemones.Add(pkmnupdate);
            }
            return pokemones.ListaPokemones;
        }

        // DELETE api/<PokemonController>/5
        [HttpDelete("{nombre}")]
        public IEnumerable<Pokemon> Delete(string nombre)
        {
            Pokemon? p = pokemones.ListaPokemones.FirstOrDefault(x => x.Nombre == nombre);
            if(p != null)
            {
                pokemones.ListaPokemones.Remove(p);
            }

            return pokemones.ListaPokemones;
        }
    }
}
