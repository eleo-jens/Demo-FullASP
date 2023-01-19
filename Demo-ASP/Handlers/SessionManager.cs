using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session; 

        public SessionManager(IHttpContextAccessor accessor)
        {
            // donner un accès à la session
            _session = accessor.HttpContext.Session; 
        }

        // propriété permettant de sauvegarder le currentUser
        public CurrentUser CurrentUser
        {
            get {
                string data = _session.GetString(nameof(CurrentUser)); 
                if (data is null) return null;
                return JsonSerializer.Deserialize<CurrentUser>(data);
            }
            set {
                // si ma valeur est null, à la place de sauvegarder un null (chose que le serializer ne va pas comprendre), je lui demande de supprimer l'information : dans le cas ou on met à null le currentuser dans logout
                if (value is null) _session.Remove(nameof(CurrentUser));
                _session.SetString(
                    nameof(CurrentUser), 
                    JsonSerializer.Serialize(value)); 
            }

        }
    }
}
