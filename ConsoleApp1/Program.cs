public Text goldText;
public Text crystalText;
public Text foodText;

void UpdateResourceText(Text resourceText, int amount) {
    resourceText.text = "Amount: " + amount.ToString();
}
