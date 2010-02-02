using System;
using System.Collections;
using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class FileGroupFiles : List<FileGroupFile>
    {
        private readonly Hashtable hash = new Hashtable();
        private readonly FileGroup parent;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="parent">
        /// Objeto Database padre.
        /// </param>
        public FileGroupFiles(FileGroup parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Clona el objeto FileGroups en una nueva instancia.
        /// </summary>
        public FileGroupFiles Clone(FileGroup parentObject)
        {
            var columns = new FileGroupFiles(parentObject);
            for (var index = 0; index < Count; index++)
            {
                columns.Add((FileGroupFile)this[index].Clone());
            }
            return columns;
        }

        /// <summary>
        /// Indica si el nombre del FileGroup existe en la coleccion de tablas del objeto.
        /// </summary>
        /// <param name="table">
        /// Nombre de la tabla a buscar.
        /// </param>
        /// <returns></returns>
        public Boolean Find(string table)
        {
            return hash.ContainsKey(table);
        }

        /// <summary>
        /// Agrega un objeto columna a la coleccion de columnas.
        /// </summary>
        public new void Add(FileGroupFile file)
        {
            if (file != null)
            {
                hash.Add(file.FullName, file);
                base.Add(file);
            }
            else
                throw new ArgumentNullException("file");
        }

        public FileGroupFile this[string name]
        {
            get { return (FileGroupFile)hash[name]; }
            set
            {
                hash[name] = value;
                for (var index = 0; index < Count; index++)
                {
                    if (!base[index].Name.Equals(name)) continue;
                    base[index] = value;
                    break;
                }
            }
        }

        /// <summary>
        /// Devuelve la tabla perteneciente a la coleccion de campos.
        /// </summary>
        public FileGroup Parent
        {
            get { return parent; }
        }
    }
}