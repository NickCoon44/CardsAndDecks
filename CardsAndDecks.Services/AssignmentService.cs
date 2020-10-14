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
                DeckId = model.DeckId,
                NumberOfAssignments = 1
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CheckAssignment(int cardId, int deckId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var deck = ctx.Decks.Single(e => e.Id == deckId);
                var assignments = ctx.Assignments.Where(e => e.DeckId == deck.Id);
                bool exists = false;
                foreach (Assignment assignment in assignments)
                {
                    if (assignment.CardId == cardId)
                    {
                        assignment.NumberOfAssignments++;
                        exists = true;
                    }
                }

                ctx.SaveChanges();
                return exists;
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
                        DeckId = entity.DeckId,
                        NumberOfAssignments = entity.NumberOfAssignments
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
                if (entity.NumberOfAssignments > 1)
                {
                    entity.NumberOfAssignments--;
                }
                else
                {
                    ctx.Assignments.Remove(entity);
                }

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
