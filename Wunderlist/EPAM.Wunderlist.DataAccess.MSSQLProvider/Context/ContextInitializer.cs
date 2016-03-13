using System;
using System.Data.Entity;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Context
{
    class ContextInitializer : DropCreateDatabaseAlways<WunderlistContext>
    {
        protected override void Seed(WunderlistContext context)
        {
            #region User1

            TodoListModel[] user1List = {
                new TodoListModel
                {
                    Name = "Inbox",
                    TodoItems = new[]
                    {
                        new TodoItemModel
                        {
                            TodoTask = "FIRST Task Default List For User1",
                            Description = "This is default first Task For User1",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "SECOND Task Default List For User1",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "THIRD Task Default List For User1",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "FOURTH Task Default List For User1",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "FIFTH Task Default List For User1",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        }
                    }
                },
                new TodoListModel
                {
                    Name = "Work",
                    TodoItems = new[]
                    {
                        new TodoItemModel
                        {
                            TodoTask = "FIRST Task Work List For User1",
                            Description = "This is work first Task For User1",
                            Status = TodoStatus.Unfinished,
                            Date = DateTime.Today
                        },
                        new TodoItemModel
                        {
                            TodoTask = "SECOND Task Work List For User1",
                            Status = TodoStatus.Unfinished,
                            Date = DateTime.Today
                        },
                        new TodoItemModel
                        {
                            TodoTask = "THIRD Task Work List For User1",
                            Status = TodoStatus.Unfinished,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoListModel
                {
                    Name = "Shopping"
                }
            };

            UserModel user1 = new UserModel
            {
                Email = "First@gmail.com",
                Password = "AH3KUibfw1+uZNzUkYrQ5sbCXKs1QloGYGmxmEjfurc6kahgZNcq3KuZ2Wn9R+32bw==",  //FirstPassword
                TodoLists = user1List,
                Profile = new UserProfileModel
                {
                    Name = "FirstName",
                    Photo = "1.jpg"
                }
            };

            #endregion

            #region User2

            TodoListModel[] user2List = {
                new TodoListModel
                {
                    Name = "Inbox",
                    TodoItems = new[]
                    {
                        new TodoItemModel
                        {
                            TodoTask = "FIRST Task INBOX List For User2",
                            Description = "This List is default for all users",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "SECOND Task INBOX List For User2",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "FIRST COMPLETED Task INBOX List For User2",
                            Description = "This List is default for all users",
                            Status = TodoStatus.Сompleted,
                            Date = null
                        }
                    }
                },
                new TodoListModel
                {
                    Name = "Journey",
                    TodoItems = new[]
                    {
                        new TodoItemModel
                        {
                            TodoTask = "FIRST Task Journey List For User2",
                            Description = "This is Journey first Task For User2",
                            Status = TodoStatus.Unfinished,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoListModel
                {
                    Name = "Weekend",
                    TodoItems = new[]
                    {
                        new TodoItemModel
                        {
                            TodoTask = "FIRST Task Weekend List For User2",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "SECOND Task Weekend List For User2",
                            Status = TodoStatus.Unfinished,
                            Date = DateTime.Today
                        },
                        new TodoItemModel
                        {
                            TodoTask = "FIRST COMPETED Task Weekend List For User2",
                            Status = TodoStatus.Сompleted,
                            //Date = DateTime.Today
                        },
                        new TodoItemModel
                        {
                            TodoTask = "SECOND COMPETED Task Weekend List For User2",
                            Status = TodoStatus.Сompleted,
                            Date = DateTime.Today
                        }
                    }
                }
            };

            UserModel user2 = new UserModel
            {
                Email = "Second@gmail.com",
                Password = "AF/m6pDyg8jb3H15CnzY1XTZTRkISUadw2bSFYsV+fAZiCqOMxwRY2l3gVnyM2ni+A==",   //SecondPassword
                TodoLists = user2List,
                Profile = new UserProfileModel
                {
                    Name = "SecondName",
                    Photo = "1.jpg"
                }
            };

            #endregion

            #region User3

            TodoListModel[] user3List =
            {
                new TodoListModel
                {
                    Name = "Inbox"
                },
                new TodoListModel
                {
                    Name = "Journey",
                    TodoItems = new[]
                    {
                        new TodoItemModel
                        {
                            TodoTask = "FIRST Task Journey List For User3",
                            Description = "This is Journey first Task For User3",
                            Status = TodoStatus.Unfinished,
                            Date = DateTime.Today
                        }
                    }
                },
                new TodoListModel
                {
                    Name = "Weekend",
                    TodoItems = new[]
                    {
                        new TodoItemModel
                        {
                            TodoTask = "FIRST Task Weekend List For User3",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "SECOND Task Weekend List For User3",
                            Status = TodoStatus.Unfinished,
                            Date = DateTime.Today
                        },
                        new TodoItemModel
                        {
                            TodoTask = "Third Task Weekend List For User3",
                            Status = TodoStatus.Unfinished,
                            Date = null
                        },
                        new TodoItemModel
                        {
                            TodoTask = "FOURTH Task Weekend List For User3",
                            Status = TodoStatus.Unfinished,
                            Date = DateTime.Today
                        }
                    }
                }
            };

            UserModel user3 = new UserModel
            {
                Email = "Third@gmail.com",
                Password = "AGt4RQ47x3U9VQRJtys593311Cw/DytsAL6/XcechPUFgK+tkM2HhqqVHP8LO+yoPw==", //ThirdPassword
                TodoLists = user3List,
                Profile = new UserProfileModel
                {
                    Name = "ThirdName",
                    Photo = "1.jpg"
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
