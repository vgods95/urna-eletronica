using Microsoft.Extensions.DependencyInjection;
using ProjetoUrna.Interfaces;
using ProjetoUrna.Repositorios;

namespace ProjetoUrna
{
    public static class ConfiguracaoRepositoriosExtension
    {
        public static void ConfigurarRepositorios(this IServiceCollection services)
        {
            services.AddTransient<ICandidateRepositorio, CandidateRepositorio>();
            services.AddTransient<IVotingRepositorio, VotingRepositorio>();
        }
    }
}
