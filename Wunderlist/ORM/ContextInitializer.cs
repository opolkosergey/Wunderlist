using System;
using System.Data.Entity;
using ORM.Entities;

namespace ORM
{
    class ContextInitializer : DropCreateDatabaseAlways<WunderlistContext>
    {
        protected override void Seed(WunderlistContext context)
        {
            #region User1
            
            TodoList[] user1List = new TodoList[]
            {
                new TodoList()
                {
                    Name = "Default",
                    TodoItems = new TodoItem[]
                    {
                        new TodoItem()
                        {
                            TodoTask = "FIRST Task Default List For User1",
                            Description = "This is default first Task For User1",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItem()
                        {
                            TodoTask = "SECOND Task Default List For User1",
                            Status = TodoStatus.New,
                            Date = null
                        }
                    }
                },
                new TodoList()
                {
                    Name = "Work",
                    TodoItems = new TodoItem[]
                    {
                        new TodoItem()
                        {
                            TodoTask = "FIRST Task Work List For User1",
                            Description = "This is work first Task For User1",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                        new TodoItem()
                        {
                            TodoTask = "SECOND Task Work List For User1",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItem()
                        {
                            TodoTask = "THIRD Task Work List For User1",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                    }
                },
                new TodoList()
                {
                    Name = "Shopping"
                }
            };

            User user1 = new User()
            {
                Email = "First@gmail.com",
                Password = "FirstPassword",
                TodoLists = user1List,
                Profile = new UserProfile()
                {
                    Name = "FirstName"
                }
            };

            #endregion

            #region User2

            TodoList[] user2List = new TodoList[]
            {
                new TodoList()
                {
                    Name = "Default",
                    TodoItems = new TodoItem[]
                    {
                        new TodoItem()
                        {
                            TodoTask = "FIRST Task Default List For User2",
                            Description = "This List is default for all users",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItem()
                        {
                            TodoTask = "SECOND Task Default List For User2",
                            Status = TodoStatus.New,
                            Date = null
                        }
                    }
                },
                new TodoList()
                {
                    Name = "Journey",
                    TodoItems = new TodoItem[]
                    {
                        new TodoItem()
                        {
                            TodoTask = "FIRST Task Journey List For User2",
                            Description = "This is Journey first Task For User2",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoList()
                {
                    Name = "Weekend",
                    TodoItems = new TodoItem[]
                    {
                        new TodoItem()
                        {
                            TodoTask = "FIRST Task Weekend List For User2",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItem()
                        {
                            TodoTask = "SECOND Task Weekend List For User2",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                    }
                }
            };

            User user2 = new User()
            {
                Email = "Second@gmail.com",
                Password = "SecondPassword",
                TodoLists = user2List,
                Profile = new UserProfile()
                {
                    Name = "SecondName"
                }
            };

            #endregion

            #region User3

            TodoList[] user3List = new TodoList[]
            {
                new TodoList()
                {
                    Name = "Default"
                },
                new TodoList()
                {
                    Name = "Journey",
                    TodoItems = new TodoItem[]
                    {
                        new TodoItem()
                        {
                            TodoTask = "FIRST Task Journey List For User3",
                            Description = "This is Journey first Task For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoList()
                {
                    Name = "Weekend",
                    TodoItems = new TodoItem[]
                    {
                        new TodoItem()
                        {
                            TodoTask = "FIRST Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItem()
                        {
                            TodoTask = "SECOND Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                        new TodoItem()
                        {
                            TodoTask = "Third Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItem()
                        {
                            TodoTask = "FOURTH Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                }
            };

            User user3 = new User()
            {
                Email = "Second@gmail.com",
                Password = "SecondPassword",
                TodoLists = user3List,
                Profile = new UserProfile()
                {
                    Name = "SecondName",
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
