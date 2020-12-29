using Microsoft.EntityFrameworkCore;
using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Collections.Generic;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Aluno SearchCpf(string cpf)
        {
            Aluno aluno_ = context.Set<Aluno>().Where(x => x.cpf == cpf)
                                  .Include(a => a.alunoTreinos).AsNoTracking().FirstOrDefault();
            return aluno_;
        }


        //Essa consulta consiste em retornar a classe Aluno e todas suas entidades filhas
        public Aluno FullSearch(Aluno aluno)
        {
            Aluno aluno_ = context.Set<Aluno>().Where(a => a.codigo == aluno.codigo)
                                               .Include(a => a.alunoTreinos)
                                               .Include(app => app.alunoPossuiPlano)
                                               .Include(app => app.alunoPossuiEquipe).Single();
            return aluno_;
        }

        //Essa listagem consiste em retornar a classe Aluno e todas suas entidades filhas
        public List<Aluno> FullList()
        {
            List<Aluno> alunos = context.Set<Aluno>().Include(a => a.alunoTreinos)
                                                     .Include(app => app.alunoPossuiPlano)
                                                     .Include(app => app.alunoPossuiEquipe).ToList();
            return alunos;
        }

    }
}
