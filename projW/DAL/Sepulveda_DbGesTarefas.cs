using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projW.Models;
using System.Data.Entity;

namespace projW.DAL
{
    public class Sepulveda_DbGesTarefas : DbContext
    {
        //public DbSet<Tarefa> Tarefas { get; set; } 
        //TTarefas | TLinhasDeTarefas | TClientes | TFuncionarios | TTiposTarefas | TTiposPrioridades

        public DbSet<Tarefa> TTarefas { get; set; }

        public DbSet<LinhaDeTarefa> TLinhasDeTarefas { get; set; }

        public DbSet<Cliente> TClientes { get; set; }

        public DbSet<Funcionario> TFuncionarios { get; set; }

        public DbSet<TipoTarefa> TTipoTarefas { get; set; }

        public DbSet<TipoPrioridade> TTipoPrioridades { get; set; }

    }
}