using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webtest2
{
    public class ProcedureClass
    {

        public string _procedure;
        public int _procedureId;
        public int _recipeId;

        public ProcedureClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ProcedureClass(string procedure, int procedureId, int recipeID)
        {

            _procedure = procedure;
            _procedureId = procedureId;
            _recipeId = recipeID;


        }

        public ProcedureClass(string procedure, int procedureId)
        {

            _procedure = procedure;
            _procedureId = procedureId;
        }

        public ProcedureClass(string procedure)
        {

            _procedure = procedure;

        }


        public string Procedure
        {
            get { return _procedure; }
            set { _procedure = value; }
        }

        public int RecipeID
        {
            get { return _recipeId; }
            set { _recipeId = value; }
        }

        public int ProcedureId
        {
            get { return _procedureId; }
            set { _procedureId = value; }
        }
    }
}