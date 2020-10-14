using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace E_LOGO.Models
{

    public static class SeedData
    {

        public static IWebHost Seed(this IWebHost webHost)
        {

            using (var scope = webHost.Services.CreateScope())
            {

                using (var context = scope.ServiceProvider.GetRequiredService<E_LOGOContext>())
                {

                    try
                    {

                        Console.Write("Seeding data ...");

                        if (context.SpeechTherapists.Count() == 0)
                        {
                            context.SpeechTherapists.AddRange(
                                new SpeechTherapist() { Id = 1, Email = "matilde", Password = "matilde", Firstname = "Matilde", Lastname = "Gravano" },
                                new SpeechTherapist() { Id = 2, Email = "pelagie", Password = "pelagie", Firstname = "Pélagie", Lastname = "Campos" }
                            );

                        }
                        context.SaveChanges();
                        if (context.Patients.Count() == 0)
                        {
                            context.Patients.AddRange(
                                 new Patient() { Id = 1, Fullname = "Pablo cousu", Diagnostique = "dyslexique", LastTaskDoneID = 1, SpeechTherapistID = 2, },
                new Patient() { Id = 2, Fullname = "Maido kapo", Diagnostique = "dyslexique", LastTaskDoneID = 2, SpeechTherapistID = 1 },
                new Patient() { Id = 3, Fullname = "Jojo tousk", Diagnostique = "aphasique", LastTaskDoneID = 2, SpeechTherapistID = 1 },
                new Patient() { Id = 4, Fullname = "Charline Dupont", Diagnostique = "dyslexique", LastTaskDoneID = 1, SpeechTherapistID = 1 },
                new Patient() { Id = 5, Fullname = "Benoit Blanc", Diagnostique = "dyslexique", LastTaskDoneID = 3, SpeechTherapistID = 2 },
                new Patient() { Id = 6, Fullname = "Maxime Gros", Diagnostique = "dyslexique", LastTaskDoneID = 1, SpeechTherapistID = 2 },
                new Patient() { Id = 7, Fullname = "Elodie Filou", Diagnostique = "dyslexique", LastTaskDoneID = 2, SpeechTherapistID = 1 },
                new Patient() { Id = 8, Fullname = "Julie Desprez", Diagnostique = "dyslexique", LastTaskDoneID = 3, SpeechTherapistID = 2 }
                            );

                        }
                        context.SaveChanges();
                        if (context.Tasks.Count() == 0)
                        {
                            context.Tasks.AddRange(
                                  new Task() { Id = 1, Name = "Tâche 1: appariement de lettres" },
                new Task() { Id = 2, Name = "Tâche 2 : Lecture de mots" },
                new Task() { Id = 3, Name = "Tâche 3: Dénomination des objets" }
                            );
                        }

                        context.SaveChanges();
                        if (context.Stimulis.Count() == 0)
                        {
                            context.Stimulis.AddRange(
                                 new Stimuli() { Id = 1, Name = "A", TaskID = 1 },
                    new Stimuli() { Id = 2, Name = "B", TaskID = 1 },
                    new Stimuli() { Id = 3, Name = "C", TaskID = 1 },
                    new Stimuli() { Id = 4, Name = "D", TaskID = 1 }
                            );

                        }
                        context.SaveChanges();
                        if (context.Responses.Count() == 0)
                        {
                            context.Responses.AddRange(
                    new Response() { Id = 1, Type = Types.Choices, StimuliID = 1, Choice = "a", isGoodAnswer = true },
                    new Response() { Id = 2, Type = Types.Choices, StimuliID = 1, Choice = "h", isGoodAnswer = false },

                    new Response() { Id = 3, Type = Types.Choices, StimuliID = 2, Choice = "d", isGoodAnswer = false },
                    new Response() { Id = 4, Type = Types.Choices, StimuliID = 2, Choice = "b", isGoodAnswer = true },

                    new Response() { Id = 5, Type = Types.Choices, StimuliID = 3, Choice = "o", isGoodAnswer = false },
                    new Response() { Id = 6, Type = Types.Choices, StimuliID = 3, Choice = "c", isGoodAnswer = true },

                    new Response() { Id = 7, Type = Types.Choices, StimuliID = 4, Choice = "n", isGoodAnswer = false },
                    new Response() { Id = 8, Type = Types.Choices, StimuliID = 4, Choice = "d", isGoodAnswer = true }
                            );

                        }
                        context.SaveChanges();
                        if (context.ResponsesPatient.Count() == 0)
                        {
                            context.ResponsesPatient.AddRange(
                                      new ResponsesPatient() { PatientID = 2, ResponseID = 1 },
                     new ResponsesPatient() { PatientID = 2, ResponseID = 3 },
                     new ResponsesPatient() { PatientID = 2, ResponseID = 5 },
                     new ResponsesPatient() { PatientID = 2, ResponseID = 7 },


                     new ResponsesPatient() { PatientID = 3, ResponseID = 2 },
                     new ResponsesPatient() { PatientID = 3, ResponseID = 4 },
                     new ResponsesPatient() { PatientID = 3, ResponseID = 5 },
                     new ResponsesPatient() { PatientID = 3, ResponseID = 8 }
                            );

                        }

                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return webHost;
        }
    }
}







