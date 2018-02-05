namespace _01.Harvesting_Fields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        private StringBuilder sb;

        public HarvestingFieldsTest()
        {
            this.sb = new StringBuilder();
        }

        internal string Run()
        {
            var command = Console.ReadLine();
            var fields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            while (command != "HARVEST")
            {
                switch (command)
                {
                    case "private":
                        this.AppendFields(fields.Where(f => f.IsPrivate));
                        break;
                    case "protected":
                        this.AppendFields(fields.Where(f => f.IsFamily));
                        break;
                    case "public":
                        this.AppendFields(fields.Where(f => f.IsPublic));
                        break;
                    case "all":
                        this.AppendFields(fields);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            return this.sb.ToString().Trim();
        }

        private void AppendFields(IEnumerable<FieldInfo> fieldsCollection)
        {
            foreach (var field in fieldsCollection)
            {
                var accessmodifier = field.Attributes.ToString().ToLower();
                if (accessmodifier.Equals("family"))
                {
                    accessmodifier = "protected";
                }

                this.sb.AppendLine($"{accessmodifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
