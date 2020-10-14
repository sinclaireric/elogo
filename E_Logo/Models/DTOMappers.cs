using System;
using System.Collections.Generic;
using System.Linq;
using E_LOGO.Models;

namespace E_LOGO.Models
{

    public static class DTOMappers
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper Authenticate  User                                          //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static AuthenticateSpeechTherapistDTO AuthenticateDTO(this SpeechTherapist st)
        {
            return new AuthenticateSpeechTherapistDTO
            {
                Id = st.Id,
                Email = st.Email,
                FirstName = st.Firstname,
                LastName = st.Lastname,
                Token = st.Token
            };
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper SpeechTherapist                                             //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //convertisseur d'un ST vers un STDTO
        public static SpeechTherapistDTO ToDTO(this SpeechTherapist st)
        {

            return new SpeechTherapistDTO
            {

                Id = st.Id,
                Email = st.Email,
                //we don't put the password in the DTO for security reasons.
                Firstname = st.Firstname,
                Lastname = st.Lastname,
                Patients = st.Patients.ToDTO()
            };

        }

        //Convertisseur d'une list de SpeechTherapists vers SpeechTherapistsDTO

        public static List<SpeechTherapistDTO> ToDTO(this IEnumerable<SpeechTherapist> sts)
        {
            return sts.Select(s => s.ToDTO()).ToList();
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper Patients                                                    //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //convertisseur d'un Patient vers un PatientDTO
        public static PatientDTO ToDTO(this Patient p)
        {

            return new PatientDTO
            {

                Id = p.Id,
                Fullname = p.Fullname,
                // Results = p.Results,
                Diagnostique = p.Diagnostique,
                LastTaskDoneID = p.LastTaskDoneID,
                SpeechTherapistID = p.SpeechTherapistID,
                //  SpeechTherapistDTO = p.SpeechTherapist.ToDTO(),
                Responses = p.Responses.Select(t => new ResponseDTO
                {

                    Id = t.Id,
                    Choice = t.Choice,
                    StimuliID = t.StimuliID,
                    // Stimuli = t.Stimuli.ToDTO(),
                    isGoodAnswer = t.isGoodAnswer
                }).ToList()
            };

        }

        //Convertisseur d'une list de Patients vers PatientDTO

        public static List<PatientDTO> ToDTO(this IEnumerable<Patient> p)
        {
            return p.Select(s => s.ToDTO()).ToList();
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper Task                                                        //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //convertisseur d'un Task vers un taskDTO
        public static TaskDTO ToDTO(this Task t)
        {

            return new TaskDTO
            {

                Id = t.Id,
                Name = t.Name,
                Stimulis = t.Stimulis.ToDTO(),
            };

        }

        //Convertisseur d'une list de Task vers TaskDTO

        public static List<TaskDTO> ToDTO(this List<Task> p)
        {
            return p.Select(s => s.ToDTO()).ToList();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper Stimuli                                                     //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //convertisseur d'un Task vers un taskDTO
        public static StimuliDTO ToDTO(this Stimuli t)
        {

            return new StimuliDTO
            {

                Id = t.Id,
                Name = t.Name,
                TaskID = t.TaskID,
                // Task = t.Task.ToDTO(),
                Responses = t.Responses.ToDTO()
            };

        }

        //Convertisseur d'une list de Task vers TaskDTO

        public static List<StimuliDTO> ToDTO(this IEnumerable<Stimuli> p)
        {
            return p.Select(s => s.ToDTO()).ToList();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                          //
        //                                    DTOMapper Responses                                                   //
        //                                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //convertisseur d'un Task vers un taskDTO
        public static ResponseDTO ToDTO(this Response t)
        {

            return new ResponseDTO
            {

                Id = t.Id,
                Choice = t.Choice,
                StimuliID = t.StimuliID,
                // Stimuli = t.Stimuli.ToDTO(), 
                isGoodAnswer = t.isGoodAnswer,
                // Patients = t.Patients.ToDTO()
            };

        }

        //Convertisseur d'une list de Task vers TaskDTO

        public static List<ResponseDTO> ToDTO(this List<Response> p)
        {
            return p.Select(s => s.ToDTO()).ToList();
        }


        public static ResponsesPatientDTO ToDTO(this ResponsesPatient responsepatient)
        {
            return new ResponsesPatientDTO
            {
                PatientID = responsepatient.PatientID,
                ResponseID = responsepatient.ResponseID,

            };
        }

        public static List<ResponsesPatientDTO> ToDTO(this List<ResponsesPatient> responsepatient)
        {
            return responsepatient.Select(v => v.ToDTO()).ToList();
        }



    }
}