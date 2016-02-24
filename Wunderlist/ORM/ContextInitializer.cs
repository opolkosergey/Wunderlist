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
            
            TodoListModel[] user1List = new TodoListModel[]
            {
                new TodoListModel()
                {
                    Name = "Default",
                    TodoItems = new TodoItemModel[]
                    {
                        new TodoItemModel()
                        {
                            TodoTask = "FIRST Task Default List For User1",
                            Description = "This is default first Task For User1",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemModel()
                        {
                            TodoTask = "SECOND Task Default List For User1",
                            Status = TodoStatus.New,
                            Date = null
                        }
                    }
                },
                new TodoListModel()
                {
                    Name = "Work",
                    TodoItems = new TodoItemModel[]
                    {
                        new TodoItemModel()
                        {
                            TodoTask = "FIRST Task Work List For User1",
                            Description = "This is work first Task For User1",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                        new TodoItemModel()
                        {
                            TodoTask = "SECOND Task Work List For User1",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemModel()
                        {
                            TodoTask = "THIRD Task Work List For User1",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                    }
                },
                new TodoListModel()
                {
                    Name = "Shopping"
                }
            };

            UserModel user1 = new UserModel()
            {
                Email = "First@gmail.com",
                Password = "FirstPassword",
                TodoLists = user1List,
                Profile = new UserProfileModel()
                {
                    Name = "FirstName"
                }
            };

            #endregion

            #region User2

            TodoListModel[] user2List = new TodoListModel[]
            {
                new TodoListModel()
                {
                    Name = "Default",
                    TodoItems = new TodoItemModel[]
                    {
                        new TodoItemModel()
                        {
                            TodoTask = "FIRST Task Default List For User2",
                            Description = "This List is default for all users",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemModel()
                        {
                            TodoTask = "SECOND Task Default List For User2",
                            Status = TodoStatus.New,
                            Date = null
                        }
                    }
                },
                new TodoListModel()
                {
                    Name = "Journey",
                    TodoItems = new TodoItemModel[]
                    {
                        new TodoItemModel()
                        {
                            TodoTask = "FIRST Task Journey List For User2",
                            Description = "This is Journey first Task For User2",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoListModel()
                {
                    Name = "Weekend",
                    TodoItems = new TodoItemModel[]
                    {
                        new TodoItemModel()
                        {
                            TodoTask = "FIRST Task Weekend List For User2",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemModel()
                        {
                            TodoTask = "SECOND Task Weekend List For User2",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                    }
                }
            };

            UserModel user2 = new UserModel()
            {
                Email = "Second@gmail.com",
                Password = "SecondPassword",
                TodoLists = user2List,
                Profile = new UserProfileModel()
                {
                    Name = "SecondName"
                }
            };

            #endregion

            #region User3

            TodoListModel[] user3List = new TodoListModel[]
            {
                new TodoListModel()
                {
                    Name = "Default"
                },
                new TodoListModel()
                {
                    Name = "Journey",
                    TodoItems = new TodoItemModel[]
                    {
                        new TodoItemModel()
                        {
                            TodoTask = "FIRST Task Journey List For User3",
                            Description = "This is Journey first Task For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoListModel()
                {
                    Name = "Weekend",
                    TodoItems = new TodoItemModel[]
                    {
                        new TodoItemModel()
                        {
                            TodoTask = "FIRST Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemModel()
                        {
                            TodoTask = "SECOND Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        },
                        new TodoItemModel()
                        {
                            TodoTask = "Third Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = null
                        },
                        new TodoItemModel()
                        {
                            TodoTask = "FOURTH Task Weekend List For User3",
                            Status = TodoStatus.New,
                            Date = DateTime.Today
                        }
                    }
                }
            };

            UserModel user3 = new UserModel()
            {
                Email = "Second@gmail.com",
                Password = "SecondPassword",
                TodoLists = user3List,
                Profile = new UserProfileModel()
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
