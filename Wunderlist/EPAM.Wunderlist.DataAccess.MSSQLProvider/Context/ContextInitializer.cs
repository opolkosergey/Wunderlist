using System;
using System.Data.Entity;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Context
{
    class ContextInitializer : DropCreateDatabaseAlways<WunderlistContext>
    {
        protected override void Seed(WunderlistContext context)
        {
            #region User1

            TodoListDbModel[] user1List = {
                new TodoListDbModel
                {
                    Name = "Default",
                    TodoItems = new[]
                    {
                        new TodoItemDbModel
                        {
                            TodoTask = "FIRST Task Default List For User1",
                            Description = "This is default first Task For User1",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemDbModel
                        {
                            TodoTask = "SECOND Task Default List For User1",
                            Status = TodoStatus.New,
                            Date = null
                        }
                    }
                },
                new TodoListDbModel
                {
                    Name = "Work",
                    TodoItems = new[]
                    {
                        new TodoItemDbModel
                        {
                            TodoTask = "FIRST Task Work List For User1",
                            Description = "This is work first Task For User1",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                        new TodoItemDbModel
                        {
                            TodoTask = "SECOND Task Work List For User1",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemDbModel
                        {
                            TodoTask = "THIRD Task Work List For User1",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoListDbModel
                {
                    Name = "Shopping"
                }
            };

            UserDbModel user1 = new UserDbModel
            {
                Email = "First@gmail.com",
                Password = "FirstPassword",
                TodoLists = user1List,
                Profile = new UserProfileDbModel
                {
                    Name = "FirstName"
                }
            };

            #endregion

            #region User2

            TodoListDbModel[] user2List = {
                new TodoListDbModel
                {
                    Name = "Default",
                    TodoItems = new[]
                    {
                        new TodoItemDbModel
                        {
                            TodoTask = "FIRST Task Default List For User2",
                            Description = "This List is default for all users",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemDbModel
                        {
                            TodoTask = "SECOND Task Default List For User2",
                            Status = TodoStatus.New,
                            Date = null
                        }
                    }
                },
                new TodoListDbModel
                {
                    Name = "Journey",
                    TodoItems = new[]
                    {
                        new TodoItemDbModel
                        {
                            TodoTask = "FIRST Task Journey List For User2",
                            Description = "This is Journey first Task For User2",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoListDbModel
                {
                    Name = "Weekend",
                    TodoItems = new[]
                    {
                        new TodoItemDbModel
                        {
                            TodoTask = "FIRST Task Weekend List For User2",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemDbModel
                        {
                            TodoTask = "SECOND Task Weekend List For User2",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                }
            };

            UserDbModel user2 = new UserDbModel
            {
                Email = "Second@gmail.com",
                Password = "SecondPassword",
                TodoLists = user2List,
                Profile = new UserProfileDbModel
                {
                    Name = "SecondName"
                }
            };

            #endregion

            #region User3

            TodoListDbModel[] user3List = {
                new TodoListDbModel
                {
                    Name = "Default"
                },
                new TodoListDbModel
                {
                    Name = "Journey",
                    TodoItems = new[]
                    {
                        new TodoItemDbModel
                        {
                            TodoTask = "FIRST Task Journey List For User3",
                            Description = "This is Journey first Task For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoListDbModel
                {
                    Name = "Weekend",
                    TodoItems = new[]
                    {
                        new TodoItemDbModel
                        {
                            TodoTask = "FIRST Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemDbModel
                        {
                            TodoTask = "SECOND Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                        new TodoItemDbModel
                        {
                            TodoTask = "Third Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemDbModel
                        {
                            TodoTask = "FOURTH Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                }
            };

            UserDbModel user3 = new UserDbModel
            {
                Email = "Second@gmail.com",
                Password = "SecondPassword",
                TodoLists = user3List,
                Profile = new UserProfileDbModel
                {
                    Name = "SecondName"
                }
            };

            #endregion

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);

            base.Seed(context);
        }
    }
}
