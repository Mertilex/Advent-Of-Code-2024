#region "Input Declaration"

var firstList = new List<int>()
{
    (18944),
    (94847),
};

var secondList = new List<int>()
{
    (47230),
    (63037),
};

#endregion

firstList.Sort();
secondList.Sort();

var distanceCalculation = new List<int>();

for(int i = 0; i < firstList.Count; ++i)
{
    distanceCalculation.Add(Math.Abs(firstList[i] - secondList[i]));
}

var sum = distanceCalculation.Sum();

Console.WriteLine(sum);