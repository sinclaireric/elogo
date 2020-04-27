using System.Collections.Generic;
using System.Linq;
using E_LOGO.Models;

namespace E_LOGO.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<SpeechTherapist> WithoutPasswords(this IEnumerable<SpeechTherapist> st) {
            return st.Select(x => x.WithoutPassword());
        }

        public static SpeechTherapist WithoutPassword(this SpeechTherapist st) {
            st.Password = null;
            return st;
        }
    }
}