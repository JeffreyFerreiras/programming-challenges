namespace AddOne;

class Solution
{
    public int[] AddOne(int[] source)
    {
        if (source.Length == 0)
            return [1];

        int aggregator = 1;
        // [9, 9, 9, 9] + 1
        // [1, 0, 0, 0, 0]
        for (int i = source.Length - 1; i >= 0; i -= 1)
        {
            int sum = source[i] + aggregator; // 9 + 1 = 10
            source[i] = sum % 10; // 10 % 10 = 0
            aggregator = sum / 10; // 10 / 10 = 1
            if (aggregator == 0)
                break;
        }

        if (aggregator > 0)
        {
            source = [aggregator, .. source];
        }

        return source;
    }

    // public int[] AddOne(int[] sample)
    // {
    //     return AddOne(sample, sample.Length - 1);
    // }

    // private int[] AddOne(int[] arr, int index)
    // {
    //     if (index < 0)
    //     {
    //         return PrependOne(arr);
    //     }

    //     arr[index] += 1;

    //     if (arr[index] >= 10)
    //     {
    //         arr[index] %= 10;
    //         return AddOne(arr, index - 1);
    //     }

    //     return arr;
    // }

    // private int[] PrependOne(int[] arr)
    // {
    //     var newArray = new int[arr.Length + 1];
    //     newArray[0] = 1;

    //     for (int i = 0; i < arr.Length; i++)
    //     {
    //         newArray[i + 1] = arr[i];
    //     }

    //     return newArray;
    // }
}
