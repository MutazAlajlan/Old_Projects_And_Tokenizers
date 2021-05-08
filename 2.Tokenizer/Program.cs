using System;
using System.Collections.Generic;

namespace Project
{
    class Analyzer
    {
        static List<string> tokenizer(string passage)
        {
            String hex = "0123456789abcdefABCDEF";
            List<string> ls = new List<string>();
            string token = "";
            int i = 0;
            int pick = 0;

            while (i < passage.Length)
            {
                token = "#";
                pick = i + 1;
                //HEX
                if (passage[i] == '#' && pick < passage.Length && hex.Contains(passage[pick]))
                {
                    //to start check after #
                    ++i;
                    while (i < passage.Length && !char.IsWhiteSpace(passage[i]) && token.Length < 7 && hex.Contains(passage[i]))
                    {

                        token += passage[i];
                        i++;
                    }
                    while (token.Length < 7)
                    {
                        token += "0";
                    }


                    Console.WriteLine(token);
                }

                i++;
            }
            return ls;
        }
        static void TwitterTokenizer (string tweet)
        {
            List<string> mentionList = new List<string>();
            List<string> hashtagList = new List<string>();
            int index = 0;
            while (index < tweet.Length)
            {
                if ((index == 0 && tweet[index] == '@') ||
                    (tweet[index] == '@' && Char.IsWhiteSpace(tweet[index - 1]))
                    )
                {
                    string username = "";
                    if (index == 0)
                    {
                        username += tweet[index];
                    }
                    else
                    {
                        username += tweet[index];
                    }

                    int maxLen = 15;
                    while (
                        (index + 1) < tweet.Length && maxLen > 0 &&
                        (Char.IsLetterOrDigit(tweet[index + 1]) || tweet[index + 1] == '_')
                        )
                    {
                        username += tweet[++index];
                        --maxLen;
                    }

                    if (username.Length > 1)
                        mentionList.Add(username);
                }

                if (
                    (index == 0 && tweet[index] == '#') ||
                    (tweet[index] == '#' && Char.IsWhiteSpace(tweet[index - 1]))
                    )
                {
                    string hashtag = "";
                    if (index == 0)
                    {
                        hashtag += tweet[index];
                    }
                    else
                    {
                        hashtag += tweet[index];
                    }

                    while (
                        (index + 1) < tweet.Length &&
                        (Char.IsLetterOrDigit(tweet[index + 1]) || tweet[index + 1] == '_')
                        )
                    {
                        hashtag += tweet[++index];

                    }

                    if (hashtag.Length > 1)
                        hashtagList.Add(hashtag);
                }

                ++index;
            }

            Console.WriteLine($"The tweet contains {mentionList.Count} mention(s):");
            foreach (var handle in mentionList)
            {
                Console.WriteLine(handle);
            }

            Console.WriteLine($"\nThe tweet contains {hashtagList.Count} hashtag(s):");
            foreach (var hashtag in hashtagList)
            {
                Console.WriteLine(hashtag);
            }
        }

        static void Main(string[] args)
        {
            TwitterTokenizer("#المنيع_في_ليوان_المديفر @may___od368_ Replying to #المنيع_وان_المديفر@___mayod368 يلا اهمشي@mayod368في النهاية تعاد @_mayo_d368_");
            TwitterTokenizer("#BREAKING: Custodian of the Two Holy Mosques King Salman receives a phone call from the Turkish president Recep Tayyip Erdogan, exchange #Ramadan greeting @ #");
            string value = "this color is #F2AYBC #f #12C";
            tokenizer(value);
        }



    }
}