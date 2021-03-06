﻿using System;
using System.Collections.Generic;
using System.Linq;
using Changelog;

namespace ActuallyStandard.Services
{
    public class MockChangelogData : IChangelogData
    {
        public static readonly List<Dtos.ReleaseDto> Changelog;

        static MockChangelogData()
        {
            Changelog = new List<Dtos.ReleaseDto>
            {
                new Dtos.ReleaseDto
                {
                    ReleaseId = new Guid("efbf90bf-363f-4b6a-b1b6-3481922770d0"),
                    ReleaseVersion = "1.0.1",
                    ReleaseDate = DateTime.UtcNow,
                    Authors = new string[] { "Adam", "Irfan" },
                    WorkItems = new Dtos.WorkItemDto[] {
                        new Dtos.WorkItemDto{
                            Id = 3,
                            WorkItemType = 2,
                            Description = "hello"
                        }
                    }
                },
                new Dtos.ReleaseDto
                {
                    ReleaseId = new Guid("4976567d-7f03-431a-8de5-ecaf3073ab03"),
                    ReleaseVersion = "1.0.0",
                    ReleaseDate = DateTime.UtcNow.AddDays(-1),
                    Authors = new string[] { "Irfan", "Adam" },
                    WorkItems = new Dtos.WorkItemDto[] {
                        new Dtos.WorkItemDto{
                            Id = 1,
                            WorkItemType = 1,
                            Description = "hi"
                        },

                        new Dtos.WorkItemDto{
                            Id = 2,
                            WorkItemType = 1,
                            Description = "Fixed bug where mock releases only had one workflow item each"
                        }
                    }
                }

            };
        }

        public Dtos.ReleaseDto Get(string version) =>
            Changelog.FirstOrDefault(x => x.ReleaseVersion == version);

        public IEnumerable<Dtos.ReleaseDto> GetAll() =>
            Changelog;

        public void Create(Dtos.ReleaseDto release) =>
            Changelog.Add(release);

        public IEnumerable<Dtos.ReleaseDto> GetLatest(byte limit) => 
            Changelog.OrderByDescending(x => x.ReleaseDate).Take(limit);
    }
}
