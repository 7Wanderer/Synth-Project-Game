using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string[] questionsFile = File.ReadAllLines("question.txt");

List<Question> questions = new();

int k = 0;
for (int i = 0; i < questionsFile.Length-1; i++)
{
    Dictionary<string, int> values = new();
    List<Answer> answer = new();
    if (questionsFile[i] == "?")
    {
        if (i != 0) k++;
        i++;
        questions.Add(new Question(questionsFile[i]));
    }
    i++;
    string answers = questionsFile[i + 1];
    int jtemp = 0;
    for(int j = 0; j < answers.Length; j++)
    {
        if (answers[j] == ' ')
        {
            //Console.WriteLine(int.Parse(answers[j-1].ToString()));
            //Console.WriteLine(answers.Substring(jtemp+1,answers.Substring(jtemp+1).IndexOf(' ')-1));
            values.Add(answers.Substring(jtemp + 1, answers.Substring(jtemp + 1).IndexOf(' ')-1), int.Parse(answers[j - 1].ToString()));
            jtemp = j;
        }
    }
    if (questionsFile[i]!="") questions[k].answer.Add(new Answer(questionsFile[i], values));
}
List<KeyValuePair<string,int>> responses = new();

foreach(Question question in questions)
{
    int response = -1;
    while (response < 0 || response >= question.answer.Count)
    {
        Console.WriteLine(question.question);
        for (int i = 0; i < question.answer.Count; i++)
        {
            Console.Write("Type " + (i + 1) + " for: ");
            Console.WriteLine(question.answer[i].answer);
        }
        response = int.Parse(Console.ReadLine());
        response--;
    }    
    responses.AddRange(question.answer[response].values.ToArray());
}
Dictionary<string, int> score = new();
foreach(KeyValuePair<string,int> response in responses)
{
    if (score.ContainsKey(response.Key))
    {
        score[response.Key] += response.Value;
    }
    else
    {
        score.Add(response.Key, response.Value);
    }
}
score = score.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
List<string> results = new();
for(int i = 0; i < score.Count-1; i++)
{
    if(score.ElementAt(i+1).Value>score.ElementAt(i).Value)
    {
        results.Clear();
        results.Add(score.ElementAt(i).Key);
    }
    else if (score.ElementAt(i + 1).Value > score.ElementAt(i).Value)
    {
        results.Add(score.ElementAt(i).Key);
    }
}


Console.WriteLine("Goodbye, World!");

class Question
{
    public string question;
    public List<Answer> answer = new();
    public Question(string question)
    {
        this.question = question;
    }
}
class Answer
{
    public string answer;
    public Dictionary<string, int> values = new();
    public Answer(string answer, Dictionary<string, int> values)
    {
        this.answer = answer;
        this.values = values;
    }
}