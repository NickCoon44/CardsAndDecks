using CardsAndDecks.Data;
using CardsAndDecks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class AssignmentService
    {
        public bool CreateAssignment(AssignmentCreate model)
        {
            var entity = new Assignment()
            {
                CardId = model.CardId,
                DeckId = model.DeckId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public AssignmentDetail GetAssignmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Assignments
                    .Single(e => e.Id == id);
                return
                    new AssignmentDetail
                    {
                        Id = entity.Id,
                        CardId = entity.CardId,
                        DeckId = entity.DeckId
                    };
            }
        }

        public bool DeleteAssignment(int assignmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Assignments
                    .Single(e => e.Id == assignmentId);

                ctx.Assignments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
