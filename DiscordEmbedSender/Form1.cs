using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordEmbedSender
{
    public partial class Form1 : Form
    {
        private readonly DiscordApiClient apiClient;

        public Form1()
        {
            InitializeComponent();
            apiClient = new DiscordApiClient(AppSettings.BotApiBaseUrl);
            LoadServersAsync();
        }

        private async void LoadServersAsync()
        {
            try
            {
                btnSendEmbed.Enabled = false;
                var guilds = await apiClient.GetGuildsAsync();

                cmbServerSelection.DisplayMember = "Name";
                cmbServerSelection.ValueMember = "Id";
                cmbServerSelection.DataSource = guilds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Server: {ex.Message}", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSendEmbed.Enabled = true;
            }
        }

        private async void CmbServerSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServerSelection.SelectedValue != null)
            {
                await LoadChannelsAsync(cmbServerSelection.SelectedValue.ToString());
            }
        }

        private async Task LoadChannelsAsync(string guildId)
        {
            try
            {
                var channels = await apiClient.GetChannelsAsync(guildId);

                cmbChannelSelection.DisplayMember = "Name";
                cmbChannelSelection.ValueMember = "Id";
                cmbChannelSelection.DataSource = channels;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Kanäle: {ex.Message}", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RbChannel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTargetControls();
        }

        private void RbDM_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTargetControls();
        }

        private void UpdateTargetControls()
        {
            if (rbChannel.Checked)
            {
                // Kanal-Modus
                cmbServerSelection.Enabled = true;
                cmbChannelSelection.Enabled = true;
                txtUserSearch.Enabled = false;
                btnSearchUsers.Enabled = false;
                cmbUserSelection.Enabled = false;
                lblUserSearch.Enabled = false;
                lblUserSelection.Enabled = false;
            }
            else
            {
                // DM-Modus
                cmbServerSelection.Enabled = true; // Für die Nutzersuche benötigt
                cmbChannelSelection.Enabled = false;
                txtUserSearch.Enabled = true;
                btnSearchUsers.Enabled = true;
                cmbUserSelection.Enabled = true;
                lblUserSearch.Enabled = true;
                lblUserSelection.Enabled = true;
            }
        }

        private async void BtnSearchUsers_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserSearch.Text))
            {
                MessageBox.Show("Bitte geben Sie einen Suchbegriff ein.", "Hinweis",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                btnSearchUsers.Enabled = false;
                var users = await apiClient.SearchUsersAsync(txtUserSearch.Text);

                cmbUserSelection.DisplayMember = "DisplayName";
                cmbUserSelection.ValueMember = "Id";
                cmbUserSelection.DataSource = users;

                if (users.Count == 0)
                {
                    MessageBox.Show("Keine Nutzer gefunden.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Suchen der Nutzer: {ex.Message}", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSearchUsers.Enabled = true;
            }
        }

        private void BtnAddField_Click(object sender, EventArgs e)
        {
            var newRowIndex = dgvFields.Rows.Add("Neues Field", "Wert", false);
            dgvFields.CurrentCell = dgvFields.Rows[newRowIndex].Cells[0];
            dgvFields.BeginEdit(true);
        }

        private void BtnRemoveField_Click(object sender, EventArgs e)
        {
            if (dgvFields.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Möchten Sie das ausgewählte Field wirklich entfernen?",
                    "Field entfernen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dgvFields.Rows.RemoveAt(dgvFields.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie ein Field zum Entfernen aus.", "Hinweis",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                var embedBuilder = new EmbedBuilder();
                var embed = CreateEmbedFromForm(embedBuilder);

                var previewForm = new PreviewForm(embed);
                previewForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Erstellen der Vorschau: {ex.Message}", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSendEmbed_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                btnSendEmbed.Enabled = false;
                btnSendEmbed.Text = "Sende...";

                var embedBuilder = new EmbedBuilder();
                var embed = CreateEmbedFromForm(embedBuilder);

                string targetId;
                string targetType;

                if (rbChannel.Checked)
                {
                    targetId = cmbChannelSelection.SelectedValue?.ToString();
                    targetType = "channel";
                }
                else
                {
                    targetId = cmbUserSelection.SelectedValue?.ToString();
                    targetType = "dm";
                }

                var success = await apiClient.SendEmbedAsync(targetId, targetType, embed);

                if (success)
                {
                    MessageBox.Show("Embed erfolgreich gesendet!", "Erfolgreich",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optional: Form zurücksetzen
                    if (MessageBox.Show("Möchten Sie das Formular zurücksetzen?", "Zurücksetzen",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ResetForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Senden: {ex.Message}", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSendEmbed.Enabled = true;
                btnSendEmbed.Text = "Embed Senden";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) && string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Bitte geben Sie mindestens einen Titel oder eine Beschreibung ein.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (rbChannel.Checked && cmbChannelSelection.SelectedValue == null)
            {
                MessageBox.Show("Bitte wählen Sie einen Kanal aus.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (rbDM.Checked && cmbUserSelection.SelectedValue == null)
            {
                MessageBox.Show("Bitte wählen Sie einen Nutzer aus.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Farbe validieren
            if (!string.IsNullOrWhiteSpace(txtColor.Text))
            {
                string colorHex = txtColor.Text.Replace("#", "");
                if (!int.TryParse(colorHex, System.Globalization.NumberStyles.HexNumber, null, out _))
                {
                    MessageBox.Show("Ungültige Hex-Farbe. Verwenden Sie das Format #RRGGBB",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private Dictionary<string, object> CreateEmbedFromForm(EmbedBuilder embedBuilder)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                embedBuilder.SetTitle(txtTitle.Text);

            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
                embedBuilder.SetDescription(txtDescription.Text);

            if (!string.IsNullOrWhiteSpace(txtColor.Text))
                embedBuilder.SetColor(txtColor.Text);

            if (!string.IsNullOrWhiteSpace(txtThumbnail.Text))
                embedBuilder.SetThumbnail(txtThumbnail.Text);

            if (!string.IsNullOrWhiteSpace(txtImage.Text))
                embedBuilder.SetImage(txtImage.Text);

            if (!string.IsNullOrWhiteSpace(txtFooter.Text))
                embedBuilder.SetFooter(txtFooter.Text);

            if (!string.IsNullOrWhiteSpace(txtAuthor.Text))
                embedBuilder.SetAuthor(txtAuthor.Text);

            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
                embedBuilder.SetUrl(txtUrl.Text);

            if (chkTimestamp.Checked)
                embedBuilder.SetTimestamp(true);

            // Fields hinzufügen
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["Value"].Value != null)
                {
                    string name = row.Cells["Name"].Value.ToString();
                    string value = row.Cells["Value"].Value.ToString();
                    bool inline = Convert.ToBoolean(row.Cells["Inline"].Value ?? false);

                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
                    {
                        embedBuilder.AddField(name, value, inline);
                    }
                }
            }

            return embedBuilder.Build();
        }

        private void ResetForm()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            txtColor.Text = "#3498db";
            txtThumbnail.Clear();
            txtImage.Clear();
            txtFooter.Clear();
            txtAuthor.Clear();
            txtUrl.Clear();
            chkTimestamp.Checked = false;
            dgvFields.Rows.Clear();
            rbChannel.Checked = true;
        }

        private void TxtColor_Leave(object sender, EventArgs e)
        {
            // Auto-format hex color
            if (!string.IsNullOrWhiteSpace(txtColor.Text) && !txtColor.Text.StartsWith("#"))
            {
                txtColor.Text = "#" + txtColor.Text;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            apiClient?.Dispose();
            base.OnFormClosing(e);
        }
    }
}