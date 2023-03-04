using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.UnitTests.Utils;

public static class ItemsReportData
{
    private static readonly Dictionary<string, InvoiceItem> _invoiceItemTestCases = 
        new  Dictionary<string, InvoiceItem>(){
                {"banana",  new InvoiceItem(){
                    Name = "banana", 
                    Count = 9800
                }},
                {"apple",  new InvoiceItem(){
                    Name = "apple", 
                    Count = 1000
                }},
                {"pomegranate",  new InvoiceItem(){
                    Name = "pomegranate", 
                    Count = 3000
                }},
                {"orange",  new InvoiceItem(){
                    Name = "orange", 
                    Count = 3000
                }},
                {"yourFavoriteFruit",  new InvoiceItem(){
                    Name = "yourFavoriteFruit", 
                    Count = 10000
                }}
            };
    #region DateRangeCases
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
                Id = 5, 
                CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["banana"]
                }
            },
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["apple"]
                }
            }
        },
        new List<Invoice>(){
            new Invoice(){
                Id = 5, 
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
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 3).AddMinutes(15),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["banana"]
                }
            },
        new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 3),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["apple"]
                }
            }
        },
        new List<Invoice>(){
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["banana"]
                }
            },
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["apple"]
                }
            },
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 1),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["yourFavoriteFruit"]
                }
            }
        },
        new List<Invoice>(){
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["banana"]
                }
            },
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["apple"]
                }
            }
        },
        new List<Invoice>(){
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 4, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["banana"]
                }
            },
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["apple"]
                }
            }
        },
        new List<Invoice>(){
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 2, 12, 30, 0),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["banana"]
                }
            },
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 3),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["apple"]
                }
            },
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 5),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["yourFavoriteFruit"]
                }
            }
        },
        new List<Invoice>(){
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 3).AddMinutes(30),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["banana"]
                }
            },
            new Invoice(){
                Id = 5, 
                CreationDate = new DateTime(2018, 1, 4),
                InvoiceItems = new List<InvoiceItem>(){
                    _invoiceItemTestCases["apple"]
                }
            },
            new Invoice(){
                Id = 5, 
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
    public static List<Dictionary<string, long>> ResultInvoceExistTestCases = new List<Dictionary<string, long>>(){
        new Dictionary<string, long>{{"banana", _invoiceItemTestCases["banana"].Count}}, 
        new Dictionary<string, long>{{"banana", _invoiceItemTestCases["banana"].Count}}, 
        new Dictionary<string, long>{{"banana", _invoiceItemTestCases["banana"].Count}, {"pomegranate", _invoiceItemTestCases["pomegranate"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}, {"yourFavoriteFruit", _invoiceItemTestCases["yourFavoriteFruit"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}},
        new Dictionary<string, long>{{"banana", _invoiceItemTestCases["banana"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}, {"banana", _invoiceItemTestCases["banana"].Count}},
        new Dictionary<string, long>{{"apple", _invoiceItemTestCases["apple"].Count}, {"banana", _invoiceItemTestCases["banana"].Count}},
    };
}