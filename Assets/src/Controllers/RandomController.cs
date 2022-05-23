using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace src.Controllers
{
    public static class RandomController
    {
        public static T GetRandomItem<T>(this IList<T> items)
        {
            if (items == null)
            {
                throw new NoNullAllowedException();
            }

            int index = Random.Range(0, items.Count);
            return items[index];
        }
    }
}