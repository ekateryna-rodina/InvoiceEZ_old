using System;
using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.Shared.MockData
{
    public static class Invoices
    {
        private static readonly Dictionary<string, InvoiceItem> _invoiceItemTestCases =
    new Dictionary<string, InvoiceItem>(){
                {"banana",  new InvoiceItem(){
                    Name = "banana",
                    Count = 9800,
                    Price = 3.0m
                }},
                {"apple",  new InvoiceItem(){
                    Name = "apple",
                    Count = 1000,
                    Price = 5.0m
                }},
                {"pomegranate",  new InvoiceItem(){
                    Name = "pomegranate",
                    Count = 3000,
                    Price = 7.0m
                }},
                {"orange",  new InvoiceItem(){
                    Name = "orange",
                    Count = 3000,
                    Price = 10.0m
                }},
                {"yourFavoriteFruit",  new InvoiceItem(){
                    Name = "yourFavoriteFruit",
                    Count = 10000,
                    Price = 12.0m
                }}
        };

        public static class ItemsReport
        {
            #region DateRangeTestCases
            public static List<(DateTime?, DateTime?)> RangeInvoiceExistCases = new List<(DateTime?, DateTime?)>(){
                    (null, null),
                    (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("9999-12-31T23:59:59.9999999")),
                    (DateTime.Parse("0001-01-01T00:00:00.0000000"), DateTime.Parse("9999-12-31T23:59:59.9999999")),
                    (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-03T00:00:00.0000000")),
                    (DateTime.Parse("0001-01-01T00:00:00.0000000"), DateTime.Parse("2018-01-01T00:00:00.0000000")),
                    (null, DateTime.Parse("2018-01-01T00:00:00.0000000")),
                    (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-05T00:00:00.0000000")),
                    (DateTime.Parse("2018-01-02T00:00:00.0000000"), DateTime.Parse("2018-01-03T00:00:00.0000000")),
                    (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-04T00:00:00.0000000"))
                };
            public static List<(DateTime?, DateTime?)> RangeNoInvoiceCases = new List<(DateTime?, DateTime?)>(){
                    (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("9999-12-31T23:59:59.9999999")),
                    (null, null),
                    (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-04T00:00:00.0000000")),
                    (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-03T00:00:00.0000000")),
                    (DateTime.Parse("0001-01-01T00:00:00.0000000"), DateTime.Parse("9999-12-31T23:59:59.9999999")),
                    (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-05T00:00:00.0000000")),
                    (DateTime.Parse("0001-01-01T00:00:00.0000000"), DateTime.Parse("2018-01-01T00:00:00.0000000")),
                    (DateTime.Parse("2018-01-02T00:00:00.0000000"), DateTime.Parse("2018-01-03T00:00:00.0000000")),
                    (null, DateTime.Parse("2018-01-01T00:00:00.0000000")),
                };
            #endregion
            #region InvoicesInTheRangeTestCases
            public static List<List<Invoice>> InvoicesInTheRangeTestCases = new List<List<Invoice>>(){
            new List<Invoice>(){
                new Invoice() {Id = 1, CreationDate = DateTime.Now.AddDays(-2),
                                InvoiceItems = new List<InvoiceItem>(){ _invoiceItemTestCases["banana"]}},
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 2,
                    CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["banana"]
                    }
                },
                new Invoice(){
                    Id = 3,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["apple"]
                    }
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 4,
                    CreationDate = new DateTime(2015, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["pomegranate"]
                    }
                },
                new Invoice(){
                    Id = 5,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["banana"]
                    }
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 6,
                    CreationDate = new DateTime(2018, 1, 3).AddMinutes(15),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["banana"]
                    }
                },
            new Invoice(){
                    Id = 7,
                    CreationDate = new DateTime(2018, 1, 3),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["apple"]
                    }
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 8,
                    CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["banana"]
                    }
                },
                new Invoice(){
                    Id = 9,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["apple"]
                    }
                },
                new Invoice(){
                    Id = 10,
                    CreationDate = new DateTime(2018, 1, 1),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["yourFavoriteFruit"]
                    }
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 11,
                    CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["banana"]
                    }
                },
                new Invoice(){
                    Id = 12,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["apple"]
                    }
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 13,
                    CreationDate = new DateTime(2018, 1, 4, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["banana"]
                    }
                },
                new Invoice(){
                    Id = 14,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["apple"]
                    }
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 15,
                    CreationDate = new DateTime(2018, 1, 2, 12, 30, 0),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["banana"]
                    }
                },
                new Invoice(){
                    Id = 16,
                    CreationDate = new DateTime(2018, 1, 3),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["apple"]
                    }
                },
                new Invoice(){
                    Id = 17,
                    CreationDate = new DateTime(2018, 1, 5),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["yourFavoriteFruit"]
                    }
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 18,
                    CreationDate = new DateTime(2018, 1, 3).AddMinutes(30),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["banana"]
                    }
                },
                new Invoice(){
                    Id = 19,
                    CreationDate = new DateTime(2018, 1, 4),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["apple"]
                    }
                },
                new Invoice(){
                    Id = 20,
                    CreationDate = new DateTime(2018, 1, 4).AddMinutes(30),
                    InvoiceItems = new List<InvoiceItem>(){
                        _invoiceItemTestCases["yourFavoriteFruit"]
                    }
                }
            },
        };
            #endregion
            #region InvoicesOutOfRangeTestCases   
            public static List<List<Invoice>> InvoicesOutOfRangeTestCases = new List<List<Invoice>>(){
                new List<Invoice>(){
                    new Invoice() {Id = 1, CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                                    InvoiceItems = new List<InvoiceItem>(){ _invoiceItemTestCases["banana"]}},
                },
                new List<Invoice>(){},
                new List<Invoice>(){
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 2, 12, 30, 0),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["pomegranate"]
                        }
                    },
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 8, 12, 30, 0),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["banana"]
                        }
                    }
                },
                new List<Invoice>(){
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 3).AddMinutes(15),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["banana"]
                        }
                    },
                },
                new List<Invoice>(){},
                new List<Invoice>(){
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 3).AddMinutes(-15),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["banana"]
                        }
                    },
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 5).AddMinutes(15),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["apple"]
                        }
                    }
                },
                new List<Invoice>(){
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 1).AddMinutes(1),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["banana"]
                        }
                    }
                },
                new List<Invoice>(){
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 2).AddMinutes(-1),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["apple"]
                        }
                    },
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 3).AddMinutes(1),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["yourFavoriteFruit"]
                        }
                    }
                },
                new List<Invoice>(){
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 5),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["apple"]
                        }
                    },
                    new Invoice(){
                        Id = 5,
                        CreationDate = new DateTime(2018, 1, 25),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["yourFavoriteFruit"]
                        }
                    }
                },
            };
            #endregion
            #region ResultInvoiceExistTestCases
            public static List<Dictionary<string, long>> ResultInvoceExistTestCases = new List<Dictionary<string, long>>(){
        new Dictionary<string, long>{{"banana", _invoiceItemTestCases["banana"].Count}},
        new Dictionary<string, long>{{"banana", _invoiceItemTestCases["banana"].Count}},
        new Dictionary<string, long>{{"banana", _invoiceItemTestCases["banana"].Count}, {"pomegranate", _invoiceItemTestCases["pomegranate"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}, {"yourFavoriteFruit", _invoiceItemTestCases["yourFavoriteFruit"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}},
        new Dictionary<string, long>{{"banana", _invoiceItemTestCases["banana"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}, {"banana", _invoiceItemTestCases["banana"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}, {"banana", _invoiceItemTestCases["banana"].Count}}
        };
            #endregion
        };

        public static class Total
        {
            #region InvoiceTestCases
            public static List<Invoice> InvoiceTestCases = new List<Invoice>(){
                    new Invoice()
                {
                        Id = 100,
                        CreationDate = new DateTime(2018, 1, 3).AddMinutes(-30),
                        AcceptanceDate = new DateTime(2018, 1, 3).AddMinutes(-15),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["banana"],
                            _invoiceItemTestCases["apple"],
                        }
                    },
                    new Invoice()
                    {
                        Id = 101,
                        CreationDate = new DateTime(2018, 1, 4),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["apple"],
                            _invoiceItemTestCases["yourFavoriteFruit"]
                        }
                    },
                    new Invoice()
                    {
                        Id = 102,
                        CreationDate = new DateTime(2018, 1, 4).AddMinutes(-30),
                        AcceptanceDate = new DateTime(2018, 1, 3).AddMinutes(-12),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["yourFavoriteFruit"],
                            _invoiceItemTestCases["pomegranate"]
                        }
                    },
                    new Invoice()
                    {
                        Id = 103,
                        CreationDate = new DateTime(2018, 1, 4).AddMinutes(-30),
                        AcceptanceDate = new DateTime(2018, 1, 3).AddMinutes(-12),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["yourFavoriteFruit"]
                        }
                    },
                    new Invoice()
                    {
                        Id = 104,
                        CreationDate = new DateTime(2018, 1, 4).AddMinutes(-30),
                        InvoiceItems = new List<InvoiceItem>(){
                            _invoiceItemTestCases["yourFavoriteFruit"],
                            _invoiceItemTestCases["orange"]
                        }
                    }
            };
            #endregion
            #region ResultTestCases
            public static Dictionary<int, decimal> ResultTestCases = new Dictionary<int, decimal>(){
                {100, 34400.0m},
                {101, 125000.0m},
                {102, 141000.0m },
                {103, 120000.0m },
                {104, 150000.0m }
            };
            #endregion
            public const decimal UNPAID_AMOUNT = 275000.0m;
        }
    }
}


