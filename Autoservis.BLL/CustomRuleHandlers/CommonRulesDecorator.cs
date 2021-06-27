using Csla.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Csla.Validation.CommonRules;

namespace Autoservis.CustomRuleHandlers
{
    public static class CommonRulesDecorator
    {
        public static RuleHandler RuleHandler(RuleHandler handler, string message)
        {
            return (target, e) =>
            {
                var result = handler(target, e);
                if (result == false)
                {
                    e.Description = message;
                }
                return result;
            };
        }

        public static RuleHandler RuleHandler(RuleHandler handler)
        {
            return (target, e) =>
            {
                var result = handler(target, e);
                if (result == false)
                {
                    var property = e.PropertyFriendlyName != null ? e.PropertyFriendlyName : e.PropertyName;
                    e.Description = property + " nedostaje";
                }
                return result;
            };

        }
        public static RuleHandler MaxStringRuleHandler()
        {
            return (target, e) =>
            {
                var result = CommonRules.StringMaxLength(target, e);
                if (result == false)
                {
                    var property = e.PropertyFriendlyName != null ? e.PropertyFriendlyName : e.PropertyName;
                    var maxLengthRule = e as MaxLengthRuleArgs;
                    e.Description = property + " može sadržavati najviše" + maxLengthRule.MaxLength +"znakova";
                }
                return result;
            };
        }

        public static bool StringRequired(object target, RuleArgs e,string message)
        {
            var result = CommonRules.StringRequired(target, e);
            if (result == false)
            {
                e.Description = message;
            }
            return result;
        }
    }
}
