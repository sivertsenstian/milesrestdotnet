using System.Collections.Generic;
using System.Linq;
using MilesBoxApi.Models;

namespace MilesBoxApi
{
    public static class Seed
    {

        public static void Initialize(ModelContext context)
        {
            using (context)
            {
                context.Database.EnsureCreated();

                if (context.Users.Any())
                {
                    return;
                }

                //  Users
                var users = new User[] {
                    new User { Name = "Stian", Boxes = new List<Box>(), ApiKey = "<admin_secret_here>", IsAdmin = true }
                };

                foreach(User user in users) {
                    context.Users.Add(user);
                }
                context.SaveChanges();

                // Boxes
                var boxes = new Box[] {
                    new Box() {UserId = users.Single(u => u.Name == "Stian").UserId, Description = "Test box 1"},
                    new Box() {UserId = users.Single(u => u.Name == "Stian").UserId, Description = "Test box 2"},
                    new Box() {UserId = users.Single(u => u.Name == "Stian").UserId, Description = "Test box 3"},
                    new Box() {UserId = users.Single(u => u.Name == "Stian").UserId, Description = "Test box 4"}
                };

                foreach(Box box in boxes) {
                    context.Boxes.Add(box);
                }
                context.SaveChanges();
            }
        }
    }
}
